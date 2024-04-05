namespace Entities.RequestModel.PhotoAggregate.CombinationPhotos
{
    public class InsertCombinationPhotosReqModel
    {
        public int PhotoId { get; set; }
        public string Combinations { get; set; }
        public string NotCombinations { get; set; }
        public InsertCombinationPhotosReqModel()
        {
            
        }
        public InsertCombinationPhotosReqModel(int photoId, string combinations = "", string notCombinations = "")
        {
            PhotoId = photoId;
            Combinations = combinations;
            NotCombinations = notCombinations;
        }
    }
}
