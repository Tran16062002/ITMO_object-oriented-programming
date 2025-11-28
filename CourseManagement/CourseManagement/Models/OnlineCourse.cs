namespace CourseManagement.Models
{
    public class OnlineCourse : Course
    {
        public string Platform { get; set; }
        public string MeetingLink { get; set; }

        public OnlineCourse(string title, string platform, string meetingLink)
            : base(title)
        {
            Platform = platform;
            MeetingLink = meetingLink;
        }

        public override string ToString()
        {
            return $"{base.ToString()} [Онлайн: {Platform}, ссылка: {MeetingLink}]";
        }
    }
}
