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

        /// <summary>
        /// UC3 Retrieve All data from list who's rating is greater than 3 and productid is 1 or 4 or 9
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SelectRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               where (productReviews.ProductId == 1 && productReviews.Rating > 3) ||
                               (productReviews.ProductId == 4 && productReviews.Rating > 3) ||
                               (productReviews.ProductId == 9 && productReviews.Rating > 3)
                               select productReviews;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + "\tUserId:" + list.UserId +
                    "\tRating:" + list.Rating + "\tReview:" + list.Review + "\tisLike:" + list.isLike);
            }
        }
    }
}
