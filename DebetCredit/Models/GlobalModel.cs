using System.Collections.Generic;
using System.Web.Mvc;

namespace DebetCredit.Models
{
    public class GlobalModel<T>
    {
        public T Row { get; set; } = default;
        public T[] Rows { get; set; } = new T[0];
        public BalanceType[] BalanceTypes { get; set; }
        public CategoryModel[] CategoryTypes { get; set; }

        public SelectListItem[] GetBalanceTypes(int selected)
        {
            var list = new List<SelectListItem>();

            foreach (var type in BalanceTypes)
            {
                var item = new SelectListItem
                {
                    Text = type.Name,
                    Value = type.ID.ToString()
                };

                if (type.ID == selected)
                {
                    item.Selected = true;
                }

                list.Add(item);
            }

            return list.ToArray();
        }

        public SelectListItem[] GetCategoryTypes(int selected)
        {
            var list = new List<SelectListItem>();

            foreach (var type in CategoryTypes)
            {
                var item = new SelectListItem
                {
                    Text = type.CategoryName,
                    Value = type.ID.ToString()
                };

                if (type.ID == selected)
                {
                    item.Selected = true;
                }

                list.Add(item);
            }

            return list.ToArray();
        }
    }
}
