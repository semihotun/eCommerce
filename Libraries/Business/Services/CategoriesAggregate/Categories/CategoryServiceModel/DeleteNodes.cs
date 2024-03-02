namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class DeleteNodes
    {
        public DeleteNodes(string values)
        {
            Values = values;
        }
        public DeleteNodes()
        {
        }
        public string Values { get; set; }
    }
}
