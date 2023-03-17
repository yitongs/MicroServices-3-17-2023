using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.Infrastruction.Data;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model.Request;
using Interview.ApplicationCore.Model.Response;

namespace Interview.Infrastruction.Service
{
    public class FeedbackServiceAsync:IFeedbackServiceAsync
    {
        private readonly IFeedbackRepositoryAsync feedbackRepositoryAsync;

        public FeedbackServiceAsync(IFeedbackRepositoryAsync _feedbackRepositoryAsync)
        {
            feedbackRepositoryAsync = _feedbackRepositoryAsync;
        }

        public Task<int> AddFeedbackAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                Rating = model.Rating,
                Comment = model.Comment

            };
            return feedbackRepositoryAsync.InsertAsync(feedback);
        }

        public Task<int> DeleteFeedbackAsync(int id)
        {
            return feedbackRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<FeedbackResponseModel>> GetAllFeedbackAsync()
        {
            var result = await feedbackRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new FeedbackResponseModel()
                {
                    Id = x.Id,
                    Rating = x.Rating,
                    Comment = x.Comment
                });
            }
            return null;
        }

        public async Task<FeedbackResponseModel> GetFeedbackByIdAsync(int id)
        {
            var result = await feedbackRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new FeedbackResponseModel()
                {
                    Id = result.Id,
                    Rating = result.Rating,
                    Comment = result.Comment
                };
            }
            return null;
        }

        public Task<int> UpdateFeedbackAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                Id = model.Id,
                Rating = model.Rating,
                Comment = model.Comment

            };
            return feedbackRepositoryAsync.UpdateAsync(feedback);
        }
    }
}
