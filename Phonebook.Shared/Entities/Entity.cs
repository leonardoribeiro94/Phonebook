using Flunt.Notifications;
using System;

namespace Phonebook.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
    }
}
