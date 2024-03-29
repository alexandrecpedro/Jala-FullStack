using ModularMonolith.Shared.Exceptions;

namespace WalletApi.Modules.Wallets.Application.Owners.Exceptions;

internal sealed class OwnerAlreadyExistsException(string email)
    : SharedException($"Owner with email: '{email}' already exists.")
{
    public string Email { get; } = email;
}