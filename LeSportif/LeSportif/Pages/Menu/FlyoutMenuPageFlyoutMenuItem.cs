using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSportif.Pages.Menu
{
    public class FlyoutMenuPageFlyoutMenuItem
    {
        public FlyoutMenuPageFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutMenuPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }
}