-- Insert sample todo items
INSERT INTO Todos (Text, IsCompleted, CreatedAt) VALUES 
('🎯 Plan project architecture', 1, datetime('now', '-10 days')),
('📝 Write project documentation', 1, datetime('now', '-9 days')),
('🔧 Set up development tools', 1, datetime('now', '-8 days')),
('💻 Implement core features', 0, datetime('now', '-7 days')),
('🎨 Style the user interface', 0, datetime('now', '-6 days')),
('🧪 Add comprehensive tests', 0, datetime('now', '-5 days')),
('🔍 Code review and refactoring', 0, datetime('now', '-4 days')),
('📚 Update user documentation', 0, datetime('now', '-3 days')),
('🚀 Prepare for deployment', 0, datetime('now', '-2 days')),
('🎉 Launch the application', 0, datetime('now', '-1 day'));