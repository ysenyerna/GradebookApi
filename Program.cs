

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<StudentGrade> studentGrades = [];


// Get grades
app.MapGet("/grades", () => studentGrades);

// Post a new grade
app.MapPost("/grades", (StudentGrade? newGrade) => {

	// Validate
	if (newGrade == null) {
		return Results.BadRequest("Invalid information was provided.");
	}
	if (string.IsNullOrWhiteSpace(newGrade.Student)) {
		return Results.BadRequest("Student name must not be empty.");
	}
	if (newGrade.Score < 0 || newGrade.Score > 100) {
		return Results.BadRequest("Grade score must be between 0 and 100.");
	}

	// Add grade
	studentGrades.Add(newGrade);
	return Results.Created();
});


app.Run();
