using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaadplegenPLEntityWriter
{
    using QProcessor;

    public class Program
    {
        static void Main(string[] args)
        {
            IQProcessor qprocessor = QMagazijn.QMagazijn.processor = new OracleQProcessor($"Data Source=TORDSBZ;User Id=testpiv;Password=centric;");

            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TARCGEG")), @"C:\temp").AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TOU1AKT"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TOU1HIS"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TOU2HIS"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TOU2AKT"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TNATAKT"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TNATHIS"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TOVLAKT"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TOVLHIS"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TVBPAKT"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TVBPARC"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TVBPHIS"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TVBTAKT"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TVBTHIS"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TRDKAKT"))).AsFile();
            new EntityWriter(qprocessor.Process(QMagazijn.QMagazijn.GetTableDescription("GBA_TVWZGEG"))).AsFile();

        }
    }
}
