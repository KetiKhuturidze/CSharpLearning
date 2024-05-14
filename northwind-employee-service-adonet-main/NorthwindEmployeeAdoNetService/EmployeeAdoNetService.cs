using System;
using System.Diagnostics.Metrics;
using System.Net;
#pragma warning disable
namespace NorthwindEmployeeAdoNetService;

/// <summary>
/// A service for interacting with the "Employees" table using ADO.NET.
/// </summary>
public sealed class EmployeeAdoNetService
{

    private readonly DbProviderFactory dbFactory;
    private readonly string connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeAdoNetService"/> class.
    /// </summary>
    /// <param name="dbFactory">The database provider factory used to create database connection and command instances.</param>
    /// <param name="connectionString">The connection string used to establish a database connection.</param>
    /// <exception cref="ArgumentNullException">Thrown when either <paramref name="dbFactory"/> or <paramref name="connectionString"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="connectionString"/> is empty or contains only white-space characters.</exception>
    public EmployeeAdoNetService(DbProviderFactory dbFactory, string connectionString)
    {
        if (dbFactory == null)
        {
            throw new ArgumentNullException(nameof(dbFactory));
        }

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException(null, nameof(connectionString));
        }


        this.dbFactory = dbFactory;
        this.connectionString = connectionString;
    }

    /// <summary>
    /// Retrieves a list of all employees from the Employees table of the database.
    /// </summary>
    /// <returns>A list of Employee objects representing the retrieved employees.</returns>
    public IList<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();

        using (DbConnection connection = dbFactory.CreateConnection())
        {
            if (connection == null)
            {
                throw new InvalidOperationException("Database provider does not support connection.");
            }

            connection.ConnectionString = connectionString;

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Employees";
                command.CommandType = CommandType.Text;

                connection.Open();

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(MapEmployee(reader));
                    }
                }
            }
        }

        return employees;
    }

    private static Employee MapEmployee(DbDataReader reader)
    {
        return new Employee((long)reader["EmployeeId"])
        {
            FirstName = reader["FirstName"].ToString(),
            LastName = reader["LastName"].ToString(),
            Title = reader["Title"] as string,
            BirthDate = GetDateTimeOrNull(reader, "BirthDate"),
            HireDate = GetDateTimeOrNull(reader, "HireDate"),
            TitleOfCourtesy = reader["TitleOfCourtesy"].ToString(),
            Address = reader["Address"].ToString(),
            City = reader["City"].ToString(),
            Region = reader["Region"]as string,
            PostalCode = reader["PostalCode"].ToString(),
            Country = reader["Country"].ToString(),
            HomePhone = reader["HomePhone"].ToString(),
            Extension = reader["Extension"].ToString(),
            Notes = reader["Notes"].ToString(),
            PhotoPath = reader["PhotoPath"].ToString(),
            ReportsTo = GetNullableLongValue(reader, "ReportsTo")
        };
    }

    private static DateTime? GetDateTimeOrNull(DbDataReader reader, string columnName)
    {
        int columnIndex = reader.GetOrdinal(columnName);
        return reader.IsDBNull(columnIndex) ? (DateTime?)null : reader.GetDateTime(columnIndex);
    }

    private static long? GetNullableLongValue(DbDataReader reader, string columnName)
    {
        int columnIndex = reader.GetOrdinal(columnName);

        if (reader.IsDBNull(columnIndex))
        {
            return null;
        }

        return (long?)reader[columnIndex];
    }

    /// <summary>
    /// Retrieves an employee with the specified employee ID.
    /// </summary>
    /// <param name="employeeId">The ID of the employee to retrieve.</param>
    /// <returns>The retrieved an <see cref="Employee"/> instance.</returns>
    /// <exception cref="EmployeeServiceException">Thrown if the employee is not found.</exception>
    public Employee GetEmployee(long employeeId)
    {
        using(DbConnection connection = dbFactory.CreateConnection())
        {
            connection.ConnectionString = this.connectionString;

            using(DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * from Employees where EmployeeId = @EmployeeId";
                command.CommandType = CommandType.Text;

                DbParameter dbParameter = command.CreateParameter();
                dbParameter.ParameterName = "@EmployeeId";
                dbParameter.Value = employeeId;
                command.Parameters.Add(dbParameter);

                connection.Open();
                using(DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapEmployee(reader);
                    }


                    throw new EmployeeServiceException("Employee not found.");
                }
            }
        }

    }

    /// <summary>
    /// Adds a new employee to Employee table of the database.
    /// </summary>
    /// <param name="employee">The  <see cref="Employee"/> object containing the employee's information.</param>
    /// <returns>The ID of the newly added employee.</returns>
    /// <exception cref="EmployeeServiceException">Thrown when an error occurs while adding the employee.</exception>
    public long AddEmployee(Employee employee)
    {
        using (DbConnection connection = dbFactory.CreateConnection())
        {
            if (connection == null)
            {
                throw new InvalidOperationException("Database provider does not support connection.");
            }

            connection.ConnectionString = connectionString;

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Employees (FirstName, LastName, Title, TitleOfCourtesy, " +
                    "BirthDate, HireDate, Address, City, Region, PostalCode, Country, " +
                    "HomePhone, Extension, Notes, ReportsTo, PhotoPath) VALUES (@FirstName, @LastName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Notes, @ReportsTo, @PhotoPath)";
                command.CommandType = CommandType.Text;


                AddParameter(command, "@FirstName", employee.FirstName);
                AddParameter(command, "@LastName", employee.LastName);
                AddParameter(command, "@Title", employee.Title);
                AddParameter(command, "@TitleOfCourtesy", employee.TitleOfCourtesy);
                AddParameter(command, "@BirthDate", employee.BirthDate);
                AddParameter(command, "@HireDate", employee.HireDate);
                AddParameter(command, "@Address", employee.Address);
                AddParameter(command, "@City", employee.City);
                AddParameter(command, "@Region", employee.Region);
                AddParameter(command, "@PostalCode", employee.PostalCode);
                AddParameter(command, "@Country", employee.Country);
                AddParameter(command, "@HomePhone", employee.HomePhone);
                AddParameter(command, "@Extension", employee.Extension);
                AddParameter(command, "@Notes", employee.Notes);
                AddParameter(command, "@ReportsTo", employee.ReportsTo);
                AddParameter(command, "@PhotoPath", employee.PhotoPath);

                connection.Open();

                long recordsAffected = command.ExecuteNonQuery();

                long empid = employee.Id;

                if (recordsAffected > 0)
                {
                    return employee.Id;
                }

                throw new EmployeeServiceException("Inserting an employee failed.");

            }
        }
        
    }

    private void AddParameter(DbCommand command, string parameterName, object value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = parameterName;
        parameter.Value = value;
        parameter.Value = value ?? DBNull.Value;
        command.Parameters.Add(parameter);
    }
    /// <summary>
    /// Removes an employee from the the Employee table of the database based on the provided employee ID.
    /// </summary>
    /// <param name="employeeId">The ID of the employee to remove.</param>
    /// <exception cref="EmployeeServiceException"> Thrown when an error occurs while attempting to remove the employee.</exception>
    public void RemoveEmployee(long employeeId)
    {
        using (DbConnection connection = dbFactory.CreateConnection())
        {
            if (connection == null)
            {
                throw new InvalidOperationException(null);
            }

            connection.ConnectionString = connectionString;

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
                command.CommandType = CommandType.Text;

                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@EmployeeId";
                parameter.Value = employeeId;
                command.Parameters.Add(parameter);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

            }
        }
    }

    /// <summary>
    /// Updates an employee record in the Employee table of the database.
    /// </summary>
    /// <param name="employee">The employee object containing updated information.</param>
    /// <exception cref="EmployeeServiceException">Thrown when there is an issue updating the employee record.</exception>
    public void UpdateEmployee(Employee employee)
    {
        using (DbConnection connection = dbFactory.CreateConnection())
        {
            if (connection == null)
            {
                throw new InvalidOperationException(null);
            }

            connection.ConnectionString = connectionString;

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, " +
                    "Title = @Title, TitleOfCourtesy = @TitleOfCourtesy, BirthDate = @BirthDate, HireDate = @HireDate, " +
                    "Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, " +
                    "Country = @Country, HomePhone = @HomePhone, Extension = @Extension, Notes = @Notes, " +
                    "ReportsTo = @ReportsTo, PhotoPath = @PhotoPath WHERE EmployeeId = @EmployeeId";
                command.CommandType = CommandType.Text;

                AddParameter(command, "@EmployeeId", employee.Id);
                AddParameter(command, "@FirstName", employee.FirstName);
                AddParameter(command, "@LastName", employee.LastName);
                AddParameter(command, "@Title", employee.Title);
                AddParameter(command, "@TitleOfCourtesy", employee.TitleOfCourtesy);
                AddParameter(command, "@BirthDate", employee.BirthDate);
                AddParameter(command, "@HireDate", employee.HireDate);
                AddParameter(command, "@Address", employee.Address);
                AddParameter(command, "@City", employee.City);
                AddParameter(command, "@Region", employee.Region);
                AddParameter(command, "@PostalCode", employee.PostalCode);
                AddParameter(command, "@Country", employee.Country);
                AddParameter(command, "@HomePhone", employee.HomePhone);
                AddParameter(command, "@Extension", employee.Extension);
                AddParameter(command, "@Notes", employee.Notes);
                AddParameter(command, "@ReportsTo", employee.ReportsTo);
                AddParameter(command, "@PhotoPath", employee.PhotoPath);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected <= 0)
                {
                    throw new EmployeeServiceException("Employee not found or not updated.");
                }
            }
        } 
        }
}