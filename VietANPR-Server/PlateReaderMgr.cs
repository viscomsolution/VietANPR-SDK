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

        int _max_readers = 1;



        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PlateReaderMgr()
        {
            for(int i = 0; i < _max_readers; i++)
            {
                //_readers.Add(null);
                _frees.Add(new AtomicBool(true));
            }
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

        public VehiclePlate Read(Bitmap bmp, bool cropped)
        {
            if(bmp == null)
            {
                return null;
            }

            int detectorIdx = -1;


            while(detectorIdx < 0)
            {
                lock(_locker)
                {                
                    for(int i = 0; i < _frees.Count; i++)
                    {
                        if(_frees[i].Get())
                        {
                            _frees[i].Set(false);

                            detectorIdx = i;
                            if(detectorIdx >= _readers.Count)
                            {
                                PlateReader reader = new PlateReader();
                                reader.DrawRectangle = false;
                                _readers.Add(reader);
                            }

                            break;
                        }
                    }
                }

                Thread.Sleep(10);                
            }
            VehiclePlate result = _readers[detectorIdx].Read(bmp, cropped);

            Task.Run(() =>
            {
                lock (_locker)
                    _frees[detectorIdx].Set(true);
            });


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


            while(detectorIdx < 0)
            {
                lock(_locker)
                {
                    for(int i = 0; i < _frees.Count; i++)
                    {
                        if(_frees[i].Get())
                        {
                            _frees[i].Set(false);

                            detectorIdx = i;
                            if(detectorIdx >= _readers.Count)
                            {
                                PlateReader reader = new PlateReader();
                                reader.CropPlate = true;
                                reader.DrawRectangle = false;
                                _readers.Add(reader);
                            }

                            break;
                        }
                    }
                }
            }
            VehiclePlate[] result = _readers[detectorIdx].Reads(bmp, cropped);

            Task.Run(() =>
            {
                lock(_locker)
                    _frees[detectorIdx].Set(true);
            });


            return result;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsReaderFree(int index)
        {
            if (index < 0)
                return false;


            // Ensure _readers and _frees have enough elements
            while (_readers.Count <= index)
            {
                _readers.Add(null);
            }
            while (_frees.Count <= index)
            {
                _frees.Add(new AtomicBool(true));
            }

            if (_readers[index] == null)
            {
                PlateReader reader = new PlateReader();
                reader.DrawRectangle = false;

                _readers[index] = reader;
                _frees[index].Set(false);
                return true;
            }

            if (_frees[index].Get())
            {
                _frees[index].Set(false);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int MaxReaders
        {
            get { return _max_readers; }
            set 
            { 
                _max_readers = value;
                if(_max_readers > _readers.Count)
                {
                    for(int i = _readers.Count; i < _max_readers; i++)
                    {
                        _readers.Add(new PlateReader());
                    }
                }
            }
        }
    }
}
