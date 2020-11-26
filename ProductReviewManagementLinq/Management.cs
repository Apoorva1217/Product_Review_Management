using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagementLinq
{
    public class Management
    {
        DataTable dataTable = new DataTable();
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

        /// <summary>
        /// UC4 Retrieve Count of review present for each productid
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId " + list.ProductId + "-------- Count " + list.Count);
            }
        }

        /// <summary>
        /// UC5 UC7 Retrieve only productid and review from list for all records
        /// </summary>
        public void RetrieveProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recoredData = from productReviews in listProductReview
                              select new { productReviews.ProductId, productReviews.Review };
            foreach (var list in recoredData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + "\nReview:" + list.Review + "\n-----------");
            }
        }

        /// <summary>
        /// UC6 Skip Top 5 records from the list and display other records
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SkipTopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + "\tUserId:" + list.UserId + "\tRating:" +
                    list.Rating + "\tReview:" + list.Review + "\tisLike:" + list.isLike);
            }
        }

        /// <summary>
        /// UC8 Create DataTable and add ProductId,UserId,Rating,Review and isLike fields
        /// </summary>
        /// <param name="listProductReview"></param>
        public void InsertValuesInDataTable(List<ProductReview> listProductReview)
        {
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("UserId", typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("isLike", typeof(bool));

            dataTable.Rows.Add(1, 1, 5, "Good", true);
            dataTable.Rows.Add(2, 2, 4, "Nice", true);
            dataTable.Rows.Add(3, 3, 3, "Average", true);
            dataTable.Rows.Add(4, 4, 2, "Bad", false);
            dataTable.Rows.Add(3, 5, 3.5, "Average", true);
            dataTable.Rows.Add(2, 6, 4, "Nice", true);
            dataTable.Rows.Add(6, 7, 2, "Bad", false);
            dataTable.Rows.Add(7, 8, 3, "Average", true);
            dataTable.Rows.Add(8, 9, 5, "Good", true);
            dataTable.Rows.Add(4, 10, 4, "Nice", true);
        }

        /// <summary>
        /// UC9 Retrieve All Records from datatable who's isLike value is true
        /// </summary>
        public void RetrieveDataFromTable()
        {
            var records = from products in dataTable.AsEnumerable()
                          where (products.Field<bool>("isLike") == true)
                          select products;
            foreach (var data in records)
            {
                Console.WriteLine("ProductId:" + data.Field<int>("ProductId") + "\tUserId:" + data.Field<int>("UserId") +
                    "\tRating:" + data.Field<double>("Rating") + "\tReview:" + data.Field<string>("Review") +
                    "\tisLike:" + data.Field<bool>("isLike"));
            }
        }

        /// <summary>
        /// UC10 Find average rating of each productid
        /// </summary>
        public void AverageRatingOfProductId()
        {
            var recordedData = dataTable.AsEnumerable().GroupBy(e => e.Field<int>("ProductId")).Select(x => new { ProductId = x.Key, Average = x.Average(y => y.Field<double>("Rating")) });
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId " + list.ProductId + ": Average " + list.Average);
            }
        }
    }
}
