using CORS_MediatrPattern.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CORS_MediatrPattern.Queries
{
    public static class AddData
    {
        //Command 
        public record Command(string TaskName) : IRequest<ToDo>;

        //Handler
        public class Handler : IRequestHandler<Command, ToDo>
        {
            private readonly Repository _repository;

            public Handler(Repository repository)
            {
                _repository = repository;
            }
            public async Task<ToDo> Handle(Command command, CancellationToken cancellationToken)
            {
                var Todo = new ToDo { Id = 7, Task = "New Task", IsCompleted = false };
                _repository.ToDos.Add(Todo);
                return Todo;
            }
        }
    }
}
