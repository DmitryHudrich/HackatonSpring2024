namespace ServerApp.Api.DataTransferObjects.Request;

internal record class RegistrationRequest(string Login,
                                          string Password,
                                          string? FirstName = default,
                                          string? LastName = default,
                                          string? Bio = default,
                                          string? PhotoBase64 = default);
