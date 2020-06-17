using EventSource.Commands;
using EventSource.Entities;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.IO;

namespace EventSource
{
    class Program
    {
        private static EventBroker _eventBroker = new EventBroker();

        static void Main(string[] args)
        {
            User user = new User("Vadim");

            var task = new Task(_eventBroker);
            var taskComment = new TaskComment(_eventBroker);

            _eventBroker.Command(new CreateTaskCommand(task, "ADA", "L3", user.Id));
            _eventBroker.Command(new CreateTaskCommentCommand(taskComment, "First"));

            for (int i = 0; i < 1000; i++)
            {
                _eventBroker.Command(new ChangeCommentContentCommand(taskComment, $"Descript {i}"));
                _eventBroker.Command(new ChangeTaskDescriptionCommand(task, $"Title {i}"));

            }

            string json = JsonConvert.SerializeObject(_eventBroker.AllEvents);
            File.WriteAllText(@"C:\Users\Vadim\source\Lab3\events.json", json);

            using (var file = File.Create(@"C:\Users\Vadim\source\Lab3\events.protoBuf"))
            {
                Serializer.Serialize(file, _eventBroker.AllEvents);
            }

            Console.ReadKey();
        }
    }
}
