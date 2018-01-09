using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIIK_1
{
    class De_Koder
    {
        public bool Wszystkie(bool []uzyte, ref byte marker)
        {
            int i, j = 256;
            for (i = 0; i < 256; i++)
            {
                if (uzyte[i] == true)
                {
                    j--;
                }
                else
                {
                    marker = (byte)i;
                }
                if (j == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public long Zapisz(byte z, long cnt, byte marker, FileStream wy)
        {
            long c, r, i, dl;
            if (cnt > 3)
            {
                c = cnt / 255;
                r = cnt % 255;
                for (i = 0; i < c; i++)
                {
                    wy.WriteByte(marker);
                    wy.WriteByte(Convert.ToByte(255));
                    wy.WriteByte(z);
                    //fputc(marker, wy);
                    //fputc(255, wy);
                    //fputc(z, wy);
                    //System.Diagnostics.Process.Start(@"C:\program.exe");
                }
                dl = 3 * c;
                if (r > 0)
                {
                    wy.WriteByte(marker);
                    wy.WriteByte(Convert.ToByte(r));
                    wy.WriteByte(z);
                    //fputc(marker, wy);
                    //fputc(r, wy);
                    //fputc(z, wy);
                    dl += 3;
                }
            }
            else
            {
                for (i = 0; i < cnt; i++)
                {
                    wy.WriteByte(z);
                    //fputc(z, wy);
                }
                dl = cnt;
            }
            return dl;
        }
        public void Koduj(long start, long end, FileStream wy, byte marker, FileStream we, ProgressBar progressBar)
        {
            long dl, i, to_samo, ofs, bl = 0;
            int z, ost;

            dl = end - start;
            if (dl <= 0) 
            {
                return;
            }

            ofs = wy.Position;//ftell(wy);   Position

            //byte[] b = ;
            //wy.WriteByte(Convert.ToByte(bl));
            wy.Write(BitConverter.GetBytes(bl), 0, 8);
            //fwrite(&bl, sizeof(bl), 1, wy);

            wy.WriteByte(marker);
            //fputc(marker, wy);

            we.Seek(start, SeekOrigin.Begin);
            //fseek(we, start, SEEK_SET);
            to_samo = 1;
            ost = we.ReadByte();
            //ost = fgetc(we);
            for (i = 1; i < dl; i++)
            {
                z = we.ReadByte();//getc(we);
                if (z == ost)
                {
                    to_samo++;
                }
                else
                {
                    bl += Zapisz((byte)ost, to_samo, marker/*, swWy*/, wy);
                    to_samo = 1;
                }
                ost = z;
                progressBar.Value = Convert.ToInt32((((double)we.Position / (double)we.Length)* 1000));
                Application.DoEvents();
            }
            bl += Zapisz((byte)ost, to_samo, marker/*, swWy*/, wy);
            long pos = wy.Position;//ftell(wy);
            wy.Seek(ofs, SeekOrigin.Begin);
            //fseek(wy, ofs, SEEK_SET);
            wy.Write(BitConverter.GetBytes(bl), 0, 8);
            //wy.WriteByte(Convert.ToByte(bl));
            //fwrite(&bl, sizeof(bl), 1, wy);

            wy.Seek(0, SeekOrigin.End);
            //fseek(wy, 0, SEEK_END);
            wy.Seek(pos, SeekOrigin.Begin);
            //fseek(wy, pos, SEEK_SET);
        }
    }
}
