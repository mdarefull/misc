using CommonStore.Application.Wrappers;
using KnowledgeMap.Application.Mvc.Home.ViewModels;
using KnowledgeMap.Application.Mvc.Shared.Infrastructure;
using KnowledgeMap.Application.Mvc.Shared.ViewModels;
using KnowledgeMap.Business.Abstracts;
using KnowledgeMap.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KnowledgeMap.Application.Mvc.Home
{
    public class HomeController : Controller
    {
        private readonly IHomeServices _homeServices;
        private readonly ModelMapperWrapper _mapper;
        public HomeController(IHomeServices homeServices, ModelMapperWrapper mapper)
        {
            _homeServices = homeServices;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return RedirectToActionPermanent("Topic", new { topicName = "Universe", topicId = 1 });
        }

        public ActionResult Topic(string topicName, long topicId = 1)
        {
            // What if topic doesn't exists???
            var requestedTopic = _homeServices.GetTopic(topicId);
            if (requestedTopic == null)
                return HttpNotFound("The requested topic doesn't exist.");
            if (topicName != requestedTopic.Name)
                return RedirectToActionPermanent("Topic", new { topicName = requestedTopic.Name, topicId = requestedTopic.Id });

            // TODO [CHECK] Method stub, see comments below on method definition.
            SetPath(requestedTopic);
            var viewModel = _mapper.Map<Topic, TopicViewModel>(requestedTopic);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RemoveReference(long referenceId, string returnUrl)
        {
            _homeServices.RemoveReference(referenceId);

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Topic", new { topicName = "Universe", topicId = 1 });
            else
                return Redirect(returnUrl);
        }

        [HttpPost]
        public ActionResult AddReference(long topicId, TopicReferenceViewModel newReferenceVM)
        {
            if (ModelState.IsValid)
            {
                var newReference = _mapper.Map<TopicReferenceViewModel, Reference>(newReferenceVM);
                _homeServices.AddReference(topicId, newReference);
            }

            return RedirectToAction("Topic", new { topicId });
        }

        [HttpPost]
        public ActionResult RemoveTopic(long topicId, bool keepSubtopics, bool keepReferences)
        {
            if (_homeServices.IsUniverseTopic(topicId))
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "The Universe Topic cannot be removed.");

            var topicOwner = _homeServices.RemoveTopic(topicId, keepSubtopics, keepReferences);
            if (topicOwner == null)
                return RedirectToAction("Topic", new { topicId });
            else
                return RedirectToAction("Topic", new { topicName = topicOwner.Name, topicId = topicOwner.Id });
        }

        [ChildActionOnly]
        public bool IsUniverseTopic(long topicId)
        {
            return _homeServices.IsUniverseTopic(topicId);
        }

        // TODO [FIX] This method is a stub, once the paths get separated from the navbar and set to the topic views, this method can be modified.
        private void SetPath(Topic currentTopic)
        {
            if (Session != null)
            {
                var paths = new LinkedList<PathSection>();
                while (currentTopic != null)
                {
                    var pathSection = new PathSection { TopicName = currentTopic.Name, TopicId = currentTopic.Id, };
                    paths.AddFirst(pathSection);

                    currentTopic = currentTopic.Owner;
                }
                Session[Helpers.SessionPath] = paths;
            }
            else
                System.Console.WriteLine("Session is not initialized");
        }

        // TODO [TEST]
        [HttpGet]
        public ActionResult AddTopic(long ownerId)
        {
            // Here I need to do more: I need to populate the references from the owner to display them.
            var references = _homeServices.GetReferencesFrom(ownerId);
            var referencesVm = _mapper.Map<List<Reference>,
                                           List<AddTopic_ReferenceViewModel>>(references);
            var vm = new AddTopicViewModel { OwnerId = ownerId, References = referencesVm };
            return View(vm);
        }

        // TODO [TEST] Update the tests and missing tests.
        // TODO [IMPROVE] Because I only submit the selected refs without name, 
        //  returning the view with the model won't properly render the references.
        [HttpPost]
        public ActionResult AddTopic(AddTopicViewModel newTopic)
        {
            var topic = (Topic)null;

            if (ModelState.IsValid)
            {
                // It is silly to assume that mapper will return null.
                topic = _mapper.Map<AddTopicViewModel, Topic>(newTopic);
                topic = _homeServices.AddTopic(newTopic.OwnerId, topic, newTopic.References.Select(r => r.Id));
            }

            if (topic == null)
            {
                var references = _homeServices.GetReferencesFrom(newTopic.OwnerId);
                newTopic.References = _mapper.Map<List<Reference>,
                                                  List<AddTopic_ReferenceViewModel>>
                                                  (references);
                return View(newTopic);
            }
            else
                return RedirectToAction("Topic", new { topicId = topic.Id, topicName = topic.Name });
        }
    }
}