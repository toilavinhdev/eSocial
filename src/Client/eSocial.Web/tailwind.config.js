const colors = require("tailwindcss/colors");

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    colors: {
      ...colors,
      primary: "var(--primary)",
      gray: "var(--gray)",
    },
    extend: {},
  },
  plugins: [],
};
