using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Entities;
using TaskManagementAPI.Interface;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStory _storyRepository;

        public StoryController(IStory storyRepository)
        {
            _storyRepository = storyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Story>>> GetAllStories()
        {
            var stories = await _storyRepository.GetAllStories();

            return Ok(stories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Story>> GetStoryById(int id)
        {
            var story = await _storyRepository.GetStoryById(id);

            if (story.Id == 0)
            {
                return NotFound("Story not found.");
            }

            return Ok(story);
        }

        [HttpPost]
        public async Task<ActionResult<Story>> AddStory(Story story)
        {
            var newStory = await _storyRepository.AddStory(story);

            return CreatedAtAction("AddStory", newStory);
        }

        [HttpPut]
        public async Task<ActionResult<Story>> UpdateStory(Story updatedStory)
        {
            var newStory = await _storyRepository.UpdateStory(updatedStory);

            return Ok(newStory);
        }

        [HttpDelete]
        public async Task<ActionResult<Story>> DeleteStory(int id)
        {
            var story = await _storyRepository.DeleteStory(id);

            return Ok(story);
        }

        [HttpGet("GetStoriesByManager")]
        public async Task<ActionResult<List<Response>>> GetStoriesByManager(int managerId)
        {
            var response = await _storyRepository.GetStoriesByManager(managerId);
            return Ok(response);
        }

        [HttpGet("Report")]
        public async Task<ActionResult<List<ReportResponse>>> Report(DateTime dueDate)
        {
            var response = await _storyRepository.GetReport(dueDate);
            return Ok(response);
        }
    }
}


