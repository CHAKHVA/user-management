﻿namespace UserManagementAPI.DTOs.Requests;

public record CreateUserRequest(string Username, string Email, string Password);