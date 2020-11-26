using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagementLinq
{
    public class Management
    {
        /// <summary>
        /// UC2 Retrieve Top 3 records from list who's rating is high
        /// </summary>
        /// <param name="listProductReview"></param>
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + "\tUserId:" + list.UserId + "\tRating:" +
                    list.Rating + "\tReview:" + list.Review + "\tisLike:" + list.isLike);
            }
        }
    }
}
