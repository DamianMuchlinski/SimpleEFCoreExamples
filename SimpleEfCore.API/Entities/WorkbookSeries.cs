using System;

namespace SimpleEfCore.API.Entities
{
    public class WorkbookSeries
    {
        public Workbook Workbook { get; set; }
        public Guid WorkbookId { get; set; }
        public Series Series { get; set; }
        public string SeriesId { get; set; }
    }
}
