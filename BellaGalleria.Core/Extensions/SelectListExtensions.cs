using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Core.Extensions
{
    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<Category> categories, int selectedId)
        {
            return categories.OrderBy(category => category.Name)
                .Select(category =>
                    new SelectListItem
                    {
                        Selected = (category.Id == selectedId),
                        Text = category.Name,
                        Value = category.Id.ToString()
                    });
        }
    }
}
