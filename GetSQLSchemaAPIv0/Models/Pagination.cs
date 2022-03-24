namespace GetSQLSchemaAPI.Models
{
    public class Pagination
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }

        public Pagination()
        {
            //returns 5 records if nothing is passed
            this.pageSize = 5;
            //returns the page number if non is passed
            this.pageNumber = 1;
        }

        //constructor with argument, when something is passed
        public Pagination(int pageSize, int pageNumber)
        {
            this.pageSize = pageSize > 10 ? 10 : pageSize;
            //if current page is less than 1 (?) means set it to 1 (:) else set it to value passed
            this.pageNumber = pageNumber < 1 ? 1 : pageNumber;
        }
    }
}
