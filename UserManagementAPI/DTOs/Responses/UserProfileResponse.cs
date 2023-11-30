namespace UserManagementAPI.DTOs.Responses;

public class UserProfileResponse
{
    public int UserProfileId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalNumber { get; set; }
    public int UserId { get; set; }

    public UserProfileResponse(int userProfileId, string firstName, string lastName, string personalNumber, int userId)
    {
        UserProfileId = userProfileId;
        FirstName = firstName;
        LastName = lastName;
        PersonalNumber = personalNumber;
        UserId = userId;
    }
}

