using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
/*
The intent of this pattern is to avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request.
it does that by chaining the receiving objects and passing the request along the chain until an object handle it.
Handler defines  an interface for handling requests, and optionally inmplements the successor link.
ConcrateHandler handles requests its resposibility for. It can access the successor and potentially pass the request on.

    Use Cases:
    1.When more than one object may handle a request  and the handler isnt known beforehand
    2.When you want to issue a request to one of several objects without specifying the receiver explicitly
*/
namespace ChainOfResposibility
{
    public class Document
    {
        public string Title { get; set; }
        public DateTimeOffset LastModifiesBy { get; set; }
        public bool ApprovedByLitigation { get; set; }
        public bool ApprovedByManagment { get; set; }

        public Document(string title, DateTimeOffset lastModifiesBy, bool approvedByLitigation, bool approvedByManagment)
        {
            Title = title;
            LastModifiesBy = lastModifiesBy;
            ApprovedByLitigation = approvedByLitigation;
            ApprovedByManagment = approvedByManagment;
        }
    }

    public interface IHandler<T> where T : class
    {
        IHandler<T> SetSuccessor(IHandler<T> successor);
        void Handle(T requst);
    }
    /// <summary>
    /// ConcraeteHandler
    /// </summary>
    public class DocumentTitleHandler : IHandler<Document>
    {
        private IHandler<Document> _successor;
        public void Handle(Document document)
        {
            if (document.Title == String.Empty)
            {
                throw new ValidationException(
                    new ValidationResult(
                        "Titile must be filled out", new List<string>() { "titile" }), null, null);
            }
            // go to the next handler
            _successor?.Handle(document);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return successor; 
        }
    }

    public class DocumentLastModifiedHandler : IHandler<Document>
    {
        private IHandler<Document> _successor;
        public void Handle(Document document)
        {
            if (document.LastModifiesBy < DateTime.Now.AddDays(-30))
            {
                throw new ValidationException(
                    new ValidationResult(
                        "Documetn must be modified in the last 30 days", new List<string>() { "LastModifiesBy" }), null, null);
            }
            // go to the next handler
            _successor?.Handle(document);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return successor;
        }
    }

    public class DocumentApprovedByLitigationandler : IHandler<Document>
    {
        private IHandler<Document> _successor;
        public void Handle(Document document)
        {
            if (!document.ApprovedByLitigation)
            {
                throw new ValidationException(
                    new ValidationResult(
                        "Documetn must be Apprived by litigation", new List<string>() { "ApprovedByLitigation " }), null, null);
            }
            // go to the next handler
            _successor?.Handle(document);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return successor;
        }
    }


    public class DocumentApprovedByManagmentHandler : IHandler<Document>
    {
        private IHandler<Document> _successor;
        public void Handle(Document document)
        {
            if (!document.ApprovedByManagment)
            {
                throw new ValidationException(
                    new ValidationResult(
                        "Documetn must be ApprovedByManagment", new List<string>() { "ApprovedByManagment " }), null, null);
            }
            // go to the next handler
            _successor?.Handle(document);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return successor;
        }
    }



}
