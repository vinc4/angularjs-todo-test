// Todo Controller
angular.module('todoApp')
.controller('TodoController', ['$scope', 'TodoService', function($scope, TodoService) {
    
    // Initialize the todos array
    $scope.todos = [];
    
    // Initialize the new todo input
    $scope.newTodo = '';
    
    // Loading state
    $scope.isLoading = false;
    
    // Error message
    $scope.errorMessage = '';
    
    // Function to load all todos from API
    $scope.loadTodos = function() {
        $scope.isLoading = true;
        $scope.errorMessage = '';
        
        TodoService.getAllTodos()
            .then(function(todos) {
                $scope.todos = todos;
                $scope.isLoading = false;
            })
            .catch(function(_error) {
                $scope.errorMessage = 'Failed to load todos. Please try again.';
                $scope.isLoading = false;
            });
    };
    
    // Function to add a new todo
    $scope.addTodo = function() {
        if (!$scope.newTodo || $scope.newTodo.trim() === '') {
            return;
        }
        
        var todoText = $scope.newTodo.trim();
        $scope.isLoading = true;
        $scope.errorMessage = '';
        
        TodoService.createTodo(todoText)
            .then(function(newTodo) {
                $scope.todos.push(newTodo);
                $scope.newTodo = '';
                $scope.isLoading = false;
            })
            .catch(function(_error) {
                $scope.errorMessage = 'Failed to add todo. Please try again.';
                $scope.isLoading = false;
            });
    };
    
    // Function to remove a todo by index
    $scope.removeTodo = function(index) {
        var todo = $scope.todos[index];
        if (!todo) return;
        
        $scope.isLoading = true;
        $scope.errorMessage = '';
        
        TodoService.deleteTodo(todo.id)
            .then(function() {
                $scope.todos.splice(index, 1);
                $scope.isLoading = false;
            })
            .catch(function(_error) {
                $scope.errorMessage = 'Failed to delete todo. Please try again.';
                $scope.isLoading = false;
            });
    };
    
    // Function to update a todo's completion status
    $scope.updateTodo = function(todo) {
        $scope.errorMessage = '';
        
        TodoService.updateTodo(todo.id, todo)
            .then(function(updatedTodo) {
                // Update the local todo with the response data
                angular.extend(todo, updatedTodo);
            })
            .catch(function(_error) {
                // Revert the change if API call fails
                todo.completed = !todo.completed;
                $scope.errorMessage = 'Failed to update todo. Please try again.';
            });
    };
    
    // Function to get the count of completed todos
    $scope.getCompletedCount = function() {
        return $scope.todos.filter(function(todo) {
            return todo.completed;
        }).length;
    };
    
    // Function to get the count of remaining (incomplete) todos
    $scope.getRemainingCount = function() {
        return $scope.todos.filter(function(todo) {
            return !todo.completed;
        }).length;
    };
    
    // Function to toggle all todos completion status
    $scope.toggleAll = function() {
        var allCompleted = $scope.todos.every(function(todo) {
            return todo.completed;
        });
        
        var newCompletedStatus = !allCompleted;
        $scope.isLoading = true;
        $scope.errorMessage = '';
        
        // Update all todos
        var updatePromises = $scope.todos.map(function(todo) {
            if (todo.completed !== newCompletedStatus) {
                todo.completed = newCompletedStatus;
                return TodoService.updateTodo(todo.id, todo);
            }
            return null;
        }).filter(function(promise) {
            return promise !== null;
        });
        
        Promise.all(updatePromises)
            .then(function() {
                $scope.isLoading = false;
                $scope.$apply(); // Force digest cycle since we're using native Promise
            })
            .catch(function(_error) {
                $scope.errorMessage = 'Failed to update all todos. Please try again.';
                $scope.isLoading = false;
                // Revert changes
                $scope.todos.forEach(function(todo) {
                    todo.completed = !newCompletedStatus;
                });
                $scope.$apply();
            });
    };
    
    // Function to clear all completed todos
    $scope.clearCompleted = function() {
        var completedTodos = $scope.todos.filter(function(todo) {
            return todo.completed;
        });
        
        if (completedTodos.length === 0) return;
        
        $scope.isLoading = true;
        $scope.errorMessage = '';
        
        var deletePromises = completedTodos.map(function(todo) {
            return TodoService.deleteTodo(todo.id);
        });
        
        Promise.all(deletePromises)
            .then(function() {
                $scope.todos = $scope.todos.filter(function(todo) {
                    return !todo.completed;
                });
                $scope.isLoading = false;
                $scope.$apply();
            })
            .catch(function(_error) {
                $scope.errorMessage = 'Failed to clear completed todos. Please try again.';
                $scope.isLoading = false;
                $scope.$apply();
            });
    };
    
    // Initialize the app by loading todos
    $scope.loadTodos();
}]);