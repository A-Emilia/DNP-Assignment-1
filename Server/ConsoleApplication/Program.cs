// See https://aka.ms/new-console-template for more information

using ConsoleApplication.UI;
using FileRepository;
using RepositoryContracts;

Console.WriteLine("Starting CLI app...");
IUserRepository userRepository = new UserRepository();
ICommentRepository commentRepository = new CommentRepository();
IPostRepository postRepository = new PostRepository();

CliApp cliApp = new CliApp(userRepository, commentRepository, postRepository);
await cliApp.StartAsync();