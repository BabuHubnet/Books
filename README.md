# Books
About this sample
Overview

    The application is implemented as Net Core 3.1 and Dapper for data access.

**How To Run This Sample**

To run this sample, you'll need:

    Visual Studio    
    SQL Server

**Step 1: Clone or download this repository**

From your shell or command line:
    
    git clone https://github.com/BabuHubnet/Books.git
    
or download and extract the repository .zip file.

**Step 2: Run the DB Script**

You will get the [DBCchanges] folder from the cloned repository:
    
    1_CreateBooks_Table.sql
    2_CreateBooks_Index.sql
    3_CreateBooksContents_Table.sql
    4_CreateBooksContents_Index.sql
    5_Insert_Books.sql
    6_Insert_Contents.sql
    7_SpGetBooks.sql
    8_SpGetPublisher.sql
    9_SpGetBooksContents.sql
    10_SpGetAuthor.sql
    
Run this file in your sql server.

**Step 3: Create Environment Variable in your machine**

Create Environment Variable name "BookStore" for DB connection.

    Data Source=DESKTOP-QOE4XXX\SQLEXPRESS;Initial Catalog=XXX;User ID=XXX;password=XXXXX

    ![image](https://github.com/BabuHubnet/Books/assets/155096831/a66d442a-8fb9-485e-af8b-90c03d2f8a09)


**Step 4: Run the sample**

Clean the solution, rebuild the solution, and run it.

Once you run the Books.Api web application, you are presented with the standard swagger/index.html page. 

![image](https://github.com/BabuHubnet/Books/assets/155096831/0f2e1f71-5ec7-4ff7-a411-37ae6f325ecf)

**Api : GET
/Books/BookDetails**

    Output
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

    Output :    
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

    Output :
    [
        {
            "AuthorLastName": "Hughes",
            "AuthorFirstName": "Langston",
            "Title": "Aunt Sue's Strories"
        }
    ]

**Api : GET
/Books/TotalPrice**

    Output :
       [
        {
          "totalPrice": "610.3"
        }
       ]
    
**Api : POST
/Books/SaveBookDetails**

    Input :   
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

