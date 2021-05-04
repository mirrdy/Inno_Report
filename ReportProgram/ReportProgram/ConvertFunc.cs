using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportProgram
{
    class ConvertFunc
    {
        public int StrToIntDef(string src, int def)
        {
            try
            {
                return Convert.ToInt32(src);
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public uint StrToUIntDef(string src, uint def)
        {
            try
            {
                return Convert.ToUInt32(src);
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public double StrToDoubleDef(string src, double def)
        {
            try
            {
                return Convert.ToDouble(src);
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public uint HexStrToUIntDef(string src, uint def)
        {
            try
            {
                return Convert.ToUInt32(src, 16);
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public byte HexStrToByteDef(string src, byte def)
        {
            try
            {
                return Convert.ToByte(src, 16);
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public UInt16 HexStrToUInt16Def(string src, byte def)
        {
            try
            {
                return Convert.ToUInt16(src, 16);
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public byte StrToByteDef(string src, byte def)
        {
            try
            {
                return Convert.ToByte(src);
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public double StrToFlotDef(string src, double def)
        {
            try
            {
                return Convert.ToDouble(src);
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public bool StrToBoolDef(string src, bool def)
        {
            try
            {
                return Convert.ToBoolean(src);
            }
            catch (Exception e)
            {
                return def;
            }
        }
    }
}
