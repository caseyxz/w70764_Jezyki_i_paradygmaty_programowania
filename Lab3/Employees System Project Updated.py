import json
import os

class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def __str__(self):
        return f"Name: {self.name}, Age: {self.age}, Salary: {self.salary}"

class EmployeesManager:
    def __init__(self, filename='employees.json'):
        self.filename = filename
        self.employees = self.load_employees()

    def load_employees(self):
        if os.path.exists(self.filename):
            with open(self.filename, 'r') as file:
                return [Employee(**data) for data in json.load(file)]
        return []

    def save_employees(self):
        with open(self.filename, 'w') as file:
            json.dump([vars(employee) for employee in self.employees], file)

    def add_employee(self, employee):
        self.employees.append(employee)
        self.save_employees()

    def list_employees(self):
        return [str(employee) for employee in self.employees]

    def remove_employees_by_age_range(self, min_age, max_age):
        self.employees = [employee for employee in self.employees if not (min_age <= employee.age <= max_age)]
        self.save_employees()

    def find_employee_by_name(self, name):
        return [employee for employee in self.employees if employee.name.lower() == name.lower()]

    def update_salary(self, name, new_salary):
        for employee in self.employees:
            if employee.name.lower() == name.lower():
                employee.salary = new_salary
                self.save_employees()
                return True
        return False

    def validate_employee(self, name, age, salary):
        if not name or age < 0 or salary < 0:
            raise ValueError("Invalid data: Name cannot be empty, age and salary must be non-negative.")

class FrontendManager:
    def __init__(self, manager):
        self.manager = manager

    def display_menu(self):
        print("\nMenu:")
        print("1. Add Employee")
        print("2. List Employees")
        print("3. Remove Employees by Age Range")
        print("4. Find Employee by Name")
        print("5. Update Salary")
        print("6. Exit")

    def run(self):
        while True:
            self.display_menu()
            choice = input("Choose an option: ")
            if choice == '1':
                name = input("Enter name: ")
                age = int(input("Enter age: "))
                salary = float(input("Enter salary: "))
                try:
                    self.manager.validate_employee(name, age, salary)
                    self.manager.add_employee(Employee(name, age, salary))
                    print("Employee added successfully.")
                except ValueError as e:
                    print(e)
            elif choice == '2':
                employees = self.manager.list_employees()
                print("\nEmployees List:")
                print("\n".join(employees) if employees else "No employees found.")
            elif choice == '3':
                min_age = int(input("Enter minimum age: "))
                max_age = int(input("Enter maximum age: "))
                self.manager.remove_employees_by_age_range(min_age, max_age)
                print("Employees in the age range removed.")
            elif choice == '4':
                name = input("Enter name: ")
                employees = self.manager.find_employee_by_name(name)
                if employees:
                    print("\nFound Employees:")
                    print("\n".join(map(str, employees)))
                else:
                    print("No employee found.")
            elif choice == '5':
                name = input("Enter name: ")
                new_salary = float(input("Enter new salary: "))
                if self.manager.update_salary(name, new_salary):
                    print("Salary updated successfully.")
                else:
                    print("Employee not found.")
            elif choice == '6':
                print("Exiting...")
                break
            else:
                print("Invalid option, please try again.")

class AuthManager:
    def __init__(self):
        self.admin_username = "admin"
        self.admin_password = "admin"

    def login(self):
        username = input("Enter username: ")
        password = input("Enter password: ")
        if username == self.admin_username and password == self.admin_password:
            print("Login successful.")
            return True
        else:
            print("Invalid credentials. Access denied.")
            return False


if __name__ == "__main__":
    auth = AuthManager()
    if auth.login():
        manager = EmployeesManager()
        frontend = FrontendManager(manager)
        frontend.run()