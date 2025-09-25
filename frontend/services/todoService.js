// Todo Service for API calls
angular.module('todoApp')
.service('TodoService', ['$http', '$q', function($http, $q) {
    // Backend API endpoints:
    // - HTTP (command line): http://localhost:5020/api
    // - HTTPS (Visual Studio): https://localhost:7184/api
    var API_BASE_URL = 'http://localhost:5020/api'; // Our .NET Core backend API
    
    this.getAllTodos = function() {
        var deferred = $q.defer();
        
        $http.get(API_BASE_URL + '/todos')
            .then(function(response) {
                // Data is already in the correct format from our backend
                deferred.resolve(response.data);
            })
            .catch(function(error) {
                console.error('Error fetching todos:', error);
                deferred.reject(error);
            });
            
        return deferred.promise;
    };
    
    this.createTodo = function(todoText) {
        var deferred = $q.defer();
        var newTodo = {
            title: todoText,
            completed: false,
            userId: 1
        };
        
        $http.post(API_BASE_URL + '/todos', newTodo)
            .then(function(response) {
                // Data is already in the correct format from our backend
                deferred.resolve(response.data);
            })
            .catch(function(error) {
                console.error('Error creating todo:', error);
                deferred.reject(error);
            });
            
        return deferred.promise;
    };
    
    this.updateTodo = function(todoId, todoData) {
        var deferred = $q.defer();
        var updateData = {
            title: todoData.text,
            completed: todoData.completed,
            userId: 1
        };
        
        $http.put(API_BASE_URL + '/todos/' + todoId, updateData)
            .then(function(response) {
                // Data is already in the correct format from our backend
                deferred.resolve(response.data);
            })
            .catch(function(error) {
                console.error('Error updating todo:', error);
                deferred.reject(error);
            });
            
        return deferred.promise;
    };
    
    this.deleteTodo = function(todoId) {
        var deferred = $q.defer();
        
        $http.delete(API_BASE_URL + '/todos/' + todoId)
            .then(function(response) {
                deferred.resolve(response.data);
            })
            .catch(function(error) {
                console.error('Error deleting todo:', error);
                deferred.reject(error);
            });
            
        return deferred.promise;
    };
}]);