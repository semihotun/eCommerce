﻿namespace Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel
{
    public class InsertCombinationPhotos
    {
        public int PhotoId { get; set; }
        public string Combinations { get; set; }
        public string NotCombinations { get; set; }
        public InsertCombinationPhotos()
        {
        }
        public InsertCombinationPhotos(int photoId, string combinations = "", string notCombinations = "")
        {
            PhotoId = photoId;
            Combinations = combinations;
            NotCombinations = notCombinations;
        }
    }
}
