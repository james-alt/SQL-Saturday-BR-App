using MvvmHelpers;
using SqlSaturday.Core.Entities;

namespace SqlSaturday.ViewModels
{
    public class SpeakerViewModel
        : BaseViewModel
    {
        public SpeakerViewModel(
            Speaker speaker)
        {
            Speaker = speaker;
            Title = speaker.Name;
        }

        public Speaker Speaker { get; private set; }
    }
}
