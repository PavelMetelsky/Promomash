### .NET Core, Angular Application Requirements

#### Tech Requirements:

- **Front-end**: Angular
- **Back-end**: ASP.NET Core Web API
- **ORM**: Entity Framework Core with migrations
- **Design Framework**: No design is required, optionally Angular Material can be used

The result should be presented as a working Visual Studio solution/project. Pressing **F5** should result in a working solution.

Your code will be evaluated and reviewed as if it would be a real application. This includes **application structure, best practices, code quality, and maintainability**. Demonstrate your skills, include some design patterns, and feel free to use any other libraries, frameworks, patterns, or test data you find suitable. For example, the database with country/province can contain only two test countries and 2-3 test provinces for each country (e.g., Country 1, Province 1.1, Province 1.2 is also acceptable). This data should be seeded at the application start.

If you are missing some information, do not ask - **implement it as you think is correct**.

---

### Description:

Create a simple web page that contains a **registration wizard**. The registration wizard includes two steps:

#### **Step 1** (all fields are required):

- **Login**: valid email.
- **Password**: must contain a minimum of 1 digit and 1 letter.
- **Confirm Password**: must match the "password" field.
- **"I agree" Checkbox**: required checkbox.
- **Button Next**: should validate all fields on this step and show validation errors (under the fields) or proceed to the next step.

#### **Step 2** (all fields are required):

- **Country**: drop-down list, containing a list of countries.
- **Province**: drop-down list, containing a list of provinces for the selected country. The list of provinces should be loaded via **AJAX** when the country is changed.
- **Button Save**: should validate all fields on this step and show validation errors (under the fields) or save the data from the wizard to the database using an **AJAX call**.
