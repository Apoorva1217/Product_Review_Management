using System;
using System.Collections.Generic;

namespace ProductReviewManagementLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management using LINQ!");
            
            ///UC1 Create List of Product Review
            List<ProductReview> productReview = new List<ProductReview>()
            {
                new ProductReview() { ProductId = 1,UserId = 1,Rating = 5,Review = "Good",isLike = true},
                new ProductReview() { ProductId = 2,UserId = 2,Rating = 4,Review = "Nice",isLike = true},
                new ProductReview() { ProductId = 3,UserId = 3,Rating = 3,Review = "Average",isLike = true},
                new ProductReview() { ProductId = 4,UserId = 4,Rating = 2,Review = "Bad",isLike = false},
                new ProductReview() { ProductId = 5,UserId = 5,Rating = 4,Review = "Nice",isLike = true},
                new ProductReview() { ProductId = 6,UserId = 6,Rating = 5,Review = "Good",isLike = true},
                new ProductReview() { ProductId = 4,UserId = 7,Rating = 3,Review = "Average",isLike = true},
                new ProductReview() { ProductId = 8,UserId = 8,Rating = 2,Review = "Bad",isLike = false},
                new ProductReview() { ProductId = 4,UserId = 9,Rating = 4,Review = "Nice",isLike = true},
                new ProductReview() { ProductId = 1,UserId = 10,Rating = 3.5,Review = "Good",isLike = true}
            };
            foreach (var list in productReview)
            {
                Console.WriteLine("ProductId:" + list.ProductId + "\tUserId:" + list.UserId + "\tRating:" +
                                   list.Rating + "\tReview:" + list.Rating + "\tisLike:" + list.isLike);
            }

            Management management = new Management();
            /// UC2 Retrieve Top 3 records from list who's rating is high
            management.TopRecords(productReview);
            //UC3 Retrieve All data from list who's rating is greater than 3 and productid is 1 or 4 or 9
            management.SelectRecords(productReview);
            /// UC4 Retrieve Count of review present for each productid
            management.RetrieveCountOfRecords(productReview);
            /// UC5 UC7 Retrieve only productid and review from list for all records
            management.RetrieveProductIdAndReview(productReview);
            /// UC6 Skip Top 5 records from the list and display other records
            management.SkipTopRecords(productReview);
            /// UC8 Create DataTable and add ProductId,UserId,Rating,Review and isLike fields
            management.InsertValuesInDataTable(productReview);
            /// UC9 Retrieve All Records from datatable who's isLike value is true
            management.RetrieveDataFromTable();
        }
    }
}
