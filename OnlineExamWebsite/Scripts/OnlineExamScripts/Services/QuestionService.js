angular.module("OnlineExam").service("QuestionService",
function ($http) {
    var urlbase = "http://localhost:17012/api/mcqquestions";
    this.GetAllMcqQuestions = function () {
        return $http({
            method: "get",
            url: urlbase
        });
    };
    this.AddQuestion = function (mcqQuestion) {
        var response = $http({
            method: "post",
            url: urlbase,
            data: JSON.stringify(mcqQuestion),
            dataType: "json"
        });
        return response;
    };
});