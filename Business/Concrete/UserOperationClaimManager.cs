using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager:IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            var claim = GetClaimByUserId(userOperationClaim.UserId).Data;
            claim.UserId = userOperationClaim.UserId;
            claim.OperationClaimId = userOperationClaim.OperationClaimId;
            _userOperationClaimDal.Update(claim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        public IDataResult<UserOperationClaim> GetClaimByUserId(int userId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(claim => claim.UserId == userId));
        }
    }
}