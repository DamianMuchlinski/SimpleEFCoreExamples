using System;
using System.Collections.Generic;

namespace SimpleEfCore.API.Entities
{
    public class Workbook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public string Comment { get; set; }
        public List<WorkbookSeries> WorkbookSeries { get; set; }
    }
}