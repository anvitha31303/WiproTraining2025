const express = require('express');

const app = express();
// Middleware to parse JSON and form data
// app.use(express.json());
// app.use(express.urlencoded({ extended: true }));
// GET route: Home
app.get('/', (req, res) => {
  res.send('Welcome to the homepage!');
});

// GET route: About
app.get('/about', (req, res) => {
  res.send('Learn more about us on this page.');
});
app.get('/contact', (req, res) => {
res.send('Thank you for reaching out!');
});

// Start the server
app.listen(3000, () => {
  console.log('Server is running at http://localhost:3000');
});