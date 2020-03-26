using System;
using System.Collections.Generic;

namespace SimpleEfCore.API.Entities
{
    public class Series
    {
        public string Id { get; set; }
        public byte Periodicity { get; set; }
        public DateTime? ReleaseDateTime { get; set; }
        public List<WorkbookSeries> WorkbookSeries { get; set; }
    }
}
