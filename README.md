# Books

GET
/Books/BookDetails

[
    {
        "Publisher": "Knopf",
        "AuthorFirstName": "Langston",
        "AuthorLastName": "Hughes",
        "Title": "Aunt Sue's Strories",
        "PublicationDate": "2023-12-28T13:17:26.04",
        "Price": 100.1,
        "BookContents": [
            {
                "ContentOrder": 1,
                "ContentTitle": "Bulletin of the Illinois Socirty for Psychical Research1",
                "ContentTitleUrl": "https://doi.org/10.xxxx/xxxxxx",
                "PageRange": "275-278"
            },
            {
                "ContentOrder": 2,
                "ContentTitle": "Bulletin of the Illinois Socirty for Psychical Research2",
                "ContentTitleUrl": "https://doi.org/10.xxxx/xxxxxx",
                "PageRange": "275-278"
            },
            {
                "ContentOrder": 3,
                "ContentTitle": "Bulletin of the Illinois Socirty for Psychical Research3",
                "ContentTitleUrl": "https://doi.org/10.xxxx/xxxxxx",
                "PageRange": "275-278"
            }
        ]
    }
]

GET
/Books/PublisherDetails

GET
/Books/AuthorDetails

GET
/Books/TotalPrice

Output : 
{
  "totalPrice": "610.3"
}

POST
/Books/SaveBookDetails
