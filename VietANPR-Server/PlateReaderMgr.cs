using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TGMT;
using TGMTcs;


namespace MiniServer
{
    public class PlateReaderMgr
    {
        public List<PlateReader> _readers = new List<PlateReader>();
        public List<AtomicBool> _frees = new List<AtomicBool>();
        public static object _locker = new object();
        private static PlateReaderMgr m_instance = null;

        int _max_reader = 1;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PlateReaderMgr()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static PlateReaderMgr GetInstance()
        {
            if(m_instance == null)
                m_instance = new PlateReaderMgr();
            return m_instance;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Reset()
        {
            for(int j = 0; j < _frees.Count; j++)
            {
                _frees[j].Set(true);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public VehiclePlate[] Reads(string filePath)
        {
            if(!System.IO.File.Exists(filePath))
            {
                return null;
            }
            Bitmap bmp = new Bitmap(filePath);
            VehiclePlate[] result = Reads(bmp, false);
            bmp.Dispose();
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public VehiclePlate[] Reads(Bitmap bmp, bool cropped)
        {
            if(bmp == null)
            {
                return null;
            }

            int detectorIdx = -1;
            PlateReader detector = null;

            while(detector == null)
            {
                lock(_locker)
                {
                    for(int i = 0; i < _frees.Count; i++)
                    {
                        if(!_frees[i].Get())
                            continue;

                        _frees[i].Set(false);
                        detectorIdx = i;

                        while(_readers.Count <= detectorIdx)
                        {
                            PlateReader reader = new PlateReader();
                            reader.CropPlate = true;
                            reader.DrawRectangle = false;
                            _readers.Add(reader);
                        }


                        detector = _readers[detectorIdx];
                        break;
                    }
                }

                if(detector == null)
                    Thread.Sleep(1);
            }

            try
            {
                return detector.Reads(bmp, cropped);
            }
            finally
            {
                lock(_locker)
                {
                    if(detectorIdx >= 0 && detectorIdx < _frees.Count)
                        _frees[detectorIdx].Set(true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int MaxReader
        {
            get { return _max_reader; }
            set
            {
                if(value < 1)
                    value = 1;

                lock(_locker)
                {
                    _max_reader = value;

                    while(_readers.Count < _max_reader)
                    {
                        PlateReader reader = new PlateReader();
                        reader.CropPlate = true;
                        reader.DrawRectangle = false;
                        _readers.Add(reader);
                    }

                    while(_frees.Count < _max_reader)
                    {
                        _frees.Add(new AtomicBool(true));
                    }

                    while(_readers.Count > _max_reader && _frees.Count > _max_reader)
                    {
                        int last = _readers.Count - 1;

                        // Do not remove a reader that is currently in use.
                        if(last < 0 || !_frees[last].Get())
                            break;

                        _readers.RemoveAt(last);
                        _frees.RemoveAt(last);
                    }
                }
            }
        }
    }
}
