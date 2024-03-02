using System;
namespace X.PagedList.Web.Common
{
    public class GoToFormRenderOptions
    {
        public GoToFormRenderOptions(string inputFieldName)
        {
            LabelFormat = "Go to page:";
            SubmitButtonFormat = "Go";
            InputFieldName = inputFieldName;
            InputFieldType = "number";
        }
        public GoToFormRenderOptions() : this("page")
        {
        }
        public string LabelFormat { get; set; }
        public string SubmitButtonFormat { get; set; }
        public int SubmitButtonWidth { get; set; }
        public string InputFieldName { get; set; }
        public string InputFieldType { get; set; }
        public int InputWidth { get; set; }
        public String InputFieldClass { get; set; }
        public string SubmitButtonClass { get; set; }
    }
}