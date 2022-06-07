using System;

namespace FintessCode.BL.Model
{

    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            if(start > DateTime.Now)
            {
                throw new ArgumentException("You entered the wrong time.",nameof(start));
            }
            if(finish > DateTime.Now || finish < start)
            {
                throw new ArgumentException("You entered the wrong time.", nameof(finish));
            }

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
