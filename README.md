# intership-manager-crud

Before this, I had never written a single line of code in C#. I learned the basics of the language and the use of Visual Studio Community during the development of this project.

Internship Manager was a university project where the goal was to create a CRUD that would connect to a postgreSQL database and would allow simulating the general management of internships.

The DB in postgreSQL has five tables:
- "tutor" General information of the intern (id, first name and last name).
- "tipo_tutor" Types of tutors in the system (the type 1 tutor is an academic tutor and the type 2 tutor is an industrial tutor).
- "tutor" General information of the tutor (id, first name, last name, type).
- "empresa" General information about the company (id, name).
- "pasantia" General information on the internship (intern, academic tutor, industrial tutor, company, hiring date, start date, completion date).

The project is of the Windows Form Application type using the .NET Framework, it has a graphical interface with the Visual Studio Designer tool and it has a connection class with methods to connect and disconnect from the database, as well as a query class where they find the methods to execute the different types of queries that the application needs.

This project helped me gain knowledge and practice in:

- C# General knowledge
- Use of Visual Studio Community.
- Development of Windows Form Application.
- Graphical interfaces in C#.
- Managing NuGet packages in projects.
- Communication between C# projects and postgreSQL databases.
- Complex queries.
- Data formatting to send to DB.

And more...
