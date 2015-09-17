using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.EntityParser;
using Newtonsoft.Json;
using PetaPoco;

namespace MixERP.Net.Api.Core
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Bonus Slab Details.
    /// </summary>
    [RoutePrefix("api/v1.5/core/bonus-slab-detail")]
    public class BonusSlabDetailController : ApiController
    {
        /// <summary>
        ///     The BonusSlabDetail data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Core.Data.BonusSlabDetail BonusSlabDetailContext;

        public BonusSlabDetailController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.BonusSlabDetailContext = new MixERP.Net.Schemas.Core.Data.BonusSlabDetail
            {
                Catalog = this.Catalog,
                LoginId = this.LoginId
            };
        }

        public long LoginId { get; }
        public int UserId { get; private set; }
        public int OfficeId { get; private set; }
        public string Catalog { get; }

        /// <summary>
        ///     Counts the number of bonus slab details.
        /// </summary>
        /// <returns>Returns the count of the bonus slab details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/core/bonus-slab-detail/count")]
        public long Count()
        {
            try
            {
                return this.BonusSlabDetailContext.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Returns an instance of bonus slab detail.
        /// </summary>
        /// <param name="bonusSlabDetailId">Enter BonusSlabDetailId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{bonusSlabDetailId}")]
        [Route("~/api/core/bonus-slab-detail/{bonusSlabDetailId}")]
        public MixERP.Net.Entities.Core.BonusSlabDetail Get(int bonusSlabDetailId)
        {
            try
            {
                return this.BonusSlabDetailContext.Get(bonusSlabDetailId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("get")]
        [Route("~/api/core/bonus-slab-detail/get")]
        public IEnumerable<MixERP.Net.Entities.Core.BonusSlabDetail> Get([FromUri] int[] bonusSlabDetailIds)
        {
            try
            {
                return this.BonusSlabDetailContext.Get(bonusSlabDetailIds);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 bonus slab details on each page, sorted by the property BonusSlabDetailId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/core/bonus-slab-detail")]
        public IEnumerable<MixERP.Net.Entities.Core.BonusSlabDetail> GetPagedResult()
        {
            try
            {
                return this.BonusSlabDetailContext.GetPagedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 bonus slab details on each page, sorted by the property BonusSlabDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/core/bonus-slab-detail/page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Core.BonusSlabDetail> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.BonusSlabDetailContext.GetPagedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a filtered and paginated collection containing 25 bonus slab details on each page, sorted by the property BonusSlabDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/core/bonus-slab-detail/get-where/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Core.BonusSlabDetail> GetWhere(long pageNumber, [FromBody]dynamic filters)
        {
            try
            {
                List<EntityParser.Filter> f = JsonConvert.DeserializeObject<List<EntityParser.Filter>>(filters);
                return this.BonusSlabDetailContext.GetWhere(pageNumber, f);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Displayfield is a lightweight key/value collection of bonus slab details.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of bonus slab details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/core/bonus-slab-detail/display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.BonusSlabDetailContext.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     A custom field is a user defined field for bonus slab details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of bonus slab details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/core/bonus-slab-detail/custom-fields")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields()
        {
            try
            {
                return this.BonusSlabDetailContext.GetCustomFields(null);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     A custom field is a user defined field for bonus slab details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of bonus slab details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/core/bonus-slab-detail/custom-fields/{resourceId}")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.BonusSlabDetailContext.GetCustomFields(resourceId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds or edits your instance of BonusSlabDetail class.
        /// </summary>
        /// <param name="bonusSlabDetail">Your instance of bonus slab details class to add or edit.</param>
        [AcceptVerbs("PUT")]
        [Route("add-or-edit")]
        [Route("~/api/core/bonus-slab-detail/add-or-edit")]
        public void AddOrEdit([FromBody]MixERP.Net.Entities.Core.BonusSlabDetail bonusSlabDetail)
        {
            if (bonusSlabDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.BonusSlabDetailContext.AddOrEdit(bonusSlabDetail);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds your instance of BonusSlabDetail class.
        /// </summary>
        /// <param name="bonusSlabDetail">Your instance of bonus slab details class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{bonusSlabDetail}")]
        [Route("~/api/core/bonus-slab-detail/add/{bonusSlabDetail}")]
        public void Add(MixERP.Net.Entities.Core.BonusSlabDetail bonusSlabDetail)
        {
            if (bonusSlabDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.BonusSlabDetailContext.Add(bonusSlabDetail);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Edits existing record with your instance of BonusSlabDetail class.
        /// </summary>
        /// <param name="bonusSlabDetail">Your instance of BonusSlabDetail class to edit.</param>
        /// <param name="bonusSlabDetailId">Enter the value for BonusSlabDetailId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{bonusSlabDetailId}")]
        [Route("~/api/core/bonus-slab-detail/edit/{bonusSlabDetailId}")]
        public void Edit(int bonusSlabDetailId, [FromBody] MixERP.Net.Entities.Core.BonusSlabDetail bonusSlabDetail)
        {
            if (bonusSlabDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.BonusSlabDetailContext.Update(bonusSlabDetail, bonusSlabDetailId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Deletes an existing instance of BonusSlabDetail class via BonusSlabDetailId.
        /// </summary>
        /// <param name="bonusSlabDetailId">Enter the value for BonusSlabDetailId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{bonusSlabDetailId}")]
        [Route("~/api/core/bonus-slab-detail/delete/{bonusSlabDetailId}")]
        public void Delete(int bonusSlabDetailId)
        {
            try
            {
                this.BonusSlabDetailContext.Delete(bonusSlabDetailId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }


    }
}