namespace ChatterAPI
{
    public interface IUserDataService
    {
        IEnumerable<UserChats> GetAllUsersChats();
        void AddUserChats(UserChats userChats);
        IEnumerable<User> GetAllUsers();
        void AddNewUser(User user);

    }
    public class UserDataService : IUserDataService
    {
        public static List<User> _users = new List<User>(){
            new User() { Id = "yotam", Name = "Yotam Levin", Password = "yotam123", Image = "img1.jpg", Contacts = { } },
            new User() { Id = "or", Name = "Or Drukman", Password = "or123", Image = "img1.jpg", Contacts = { } },
            new User() { Id = "dor", Name = "Dor Levi", Password = "dor123", Image = "img1.jpg", Contacts = { } },
            new User() { Id = "gal", Name = "Gal Gadot", Password = "gal123", Image = "img1.jpg", Contacts = { } }
        };

        public static List<UserChats> _AllUsersChats = new List<UserChats>(){
            new UserChats() { Username = "or", Chats = new List<Chat>(){
                            new Chat() {
                                ContactUserName = new Contact() { id = "yotam", name = "Yotam Levin", server = "localhost:7267", last = "I'm good, wanna play volleyball?", lastdate = new DateTime(2008, 5, 1, 8, 30, 52) }, 
                                Messages = new List<Message>()
                                        {new Message() { id = 18, content = "Hi, I am Yotam how are you doing?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = false},
                                         new Message() { id = 22, content = "I'm good, wanna play volleyball?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = true}}},
                            new Chat() {
                                ContactUserName = new Contact() { id = "dor", name = "Dor Levi", server = "localhost:7267", last = "I'm good!!!!!!!!", lastdate = new DateTime(2008, 5, 1, 8, 30, 52) },
                                Messages = new List<Message>()
                                        {new Message() { id = 8, content = "What's up?? I am Dor how are you doing?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = false},
                                         new Message() { id = 928, content = "I'm good!!!!!!!!", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = true}}}}},
            new UserChats() { Username = "yotam", Chats = new List<Chat>(){
                            new Chat() {
                                ContactUserName = new Contact() { id = "or", name = "Or Drukman", server = "localhost:7267", last = "I'm good, wanna play volleyball?", lastdate = new DateTime(2008, 5, 1, 8, 30, 52) },
                                Messages = new List<Message>()
                                        {new Message() { id = 13, content = "Hi, how are you doing?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = false},
                                         new Message() { id = 9, content = "I'm good, wanna play volleyball?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = true}}},
                            new Chat() {
                                ContactUserName = new Contact() { id = "dor", name = "Dor Levi", server = "localhost:7267", last = "I'm good!!!!!!!!", lastdate = new DateTime(2008, 5, 1, 8, 30, 52) },
                                Messages = new List<Message>()
                                        {new Message() { id = 15, content = "What's up?? how are you doing?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = false},
                                         new Message() { id = 200, content = "I'm good!!!!!!!!", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = true}}}}},
            new UserChats() { Username = "dor", Chats = new List<Chat>(){
                            new Chat() {
                                ContactUserName = new Contact() { id = "or", name = "Or Drukman", server = "localhost:7267", last = "I'm good, wanna play volleyball?", lastdate = new DateTime(2008, 5, 1, 8, 30, 52) },
                                Messages = new List<Message>()
                                        {new Message() { id = 18, content = "Hi, I am Yotam how are you doing?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = true},
                                         new Message() { id = 22, content = "I'm good, wanna play volleyball?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = false}}},
                            new Chat() {
                                ContactUserName = new Contact() { id = "yotam", name = "Yotam Levin", server = "localhost:7267", last = "I'm good, wanna play volleyball?", lastdate = new DateTime(2008, 5, 1, 8, 30, 52) },
                                Messages = new List<Message>()
                                        {new Message() { id = 15, content = "What's up?? how are you doing?", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = true},
                                         new Message() { id = 200, content = "I'm good!!!!!!!!", created = new DateTime(2008, 5, 1, 8, 30, 52), sent = false}}}}},
            new UserChats() { Username = "gal", Chats = new List<Chat>(){ } }

        };

        public IEnumerable<UserChats> GetAllUsersChats()
        {
            return _AllUsersChats;
        }

        public void AddUserChats(UserChats userChats)
        {
            _AllUsersChats.Add(userChats);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public void AddNewUser(User user)
        {
            _users.Add(user);
        }
    }
}