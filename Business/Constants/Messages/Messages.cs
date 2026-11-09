using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static readonly string UserAdded = "User added succesfully.";
        public static readonly string UsersListed = "Users listed succesfully.";
        public static readonly string UserListedById = "Listed User by id succesfully";
        public static readonly string UserListedByUsername = "Listed User by username succesfully";
        public static readonly string UserListedByEmail = "Listed User by email succesfully";
        public static readonly string UserRegisteredSuccessfully = "User registered successfully.";
        public static readonly string EmailAlreadyExists = "This email already exists.";
        public static readonly string UsernameAlreadyExists = "This username already exists.";
        public static readonly string UsernameDoesNotExist = "This username does not exist.";
        public static readonly string EmailDoesNotExist = "This email does not exist.";
        public static readonly string UserDoesNotExist = "User does not exist.";
        public static readonly string UserRegistered = "User registered succesfully.";
        public static readonly string InvalidLoginCredentials = "Invalid login credentials.";
        public static readonly string SuccessfulAccessToCredentials = "Accessed to login credentials successfully.";
        public static readonly string LoginSuccesful = "Logged in succesfully.";
        internal static readonly User UserNotFound;
    }
}
