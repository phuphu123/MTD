using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTD.Services
{
    public class PlaceService: BaseService
    {
        public PlaceService() : base() { }

        /// <summary>
        /// Lấy danh sách place theo cha.
        /// nếu parent =0 --> lấy tỉnh/ thành phố.
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<SelectListItem> ListItem(int parentId)
        {
            var result = (from p in Context.tblPlaces
                          where p.Parent == parentId
                          select new SelectListItem()
                          {
                              Text = p.Text,
                              Value = p.Id.ToString()
                          }).ToList();
            return result;
        }
    }
}