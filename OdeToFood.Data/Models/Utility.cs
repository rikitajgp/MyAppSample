using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OdeToFood.Data.Models
{
    public static class Utility
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<Weighter> weighters, int selectedId)
        {
            return
                weighters.OrderBy(weighter => weighter.WeighterName)
                      .Select(weighter =>
                          new SelectListItem
                          {
                              Selected = (weighter.WeighterId== selectedId),
                              Text = weighter.WeighterName,
                              Value = weighter.WeighterId.ToString()
                          });
        }
    }
}
