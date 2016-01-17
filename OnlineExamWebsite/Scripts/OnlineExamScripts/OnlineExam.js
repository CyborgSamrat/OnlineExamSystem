/// <reference path="C:\Users\shamim.ahmed\documents\visual studio 2013\Projects\OnlineExamService\OnlineExamWebsite\Views/Home/CreateQuestion.html" />
angular.module("OnlineExam", ['ui.router']).config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.when("", "/Index");

    $stateProvider
       .state("CreateQuestion", {
           url: "/CreateQuestion",
           templateUrl: "Views/Home/CreateQuestion.html",
           controller: 'QuestionController'
       })
});
