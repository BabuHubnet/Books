# Books

**Api : GET
/Books/BookDetails**

**Output :**
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

**Api : GET
/Books/PublisherDetails**

**Output :**
[
    {
        "Publisher": "Knopf",
        "AuthorLastName": "Hughes",
        "AuthorFirstName": "Langston",
        "Title": "Aunt Sue's Strories"
    }
]

**Api : GET
/Books/AuthorDetails**

**Output :**
[
    {
        "AuthorLastName": "Hughes",
        "AuthorFirstName": "Langston",
        "Title": "Aunt Sue's Strories"
    }
]

**Api : GET
/Books/TotalPrice**

**Output :** 
{
  "totalPrice": "610.3"
}

**Api : POST
/Books/SaveBookDetails**

**Input :**
[
  {
    "publisher": "string",
    "authorFirstName": "string",
    "authorLastName": "string",
    "title": "string",
    "publicationDate": "2023-12-29T06:28:00.746Z",
    "price": 0
  }
]

