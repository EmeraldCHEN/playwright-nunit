## Playwright UI Testing Best Practices

When writing Playwright tests, avoiding test failures due to selector changes is crucial. Here are some best practices:

### 1️⃣ Use More Stable Selectors
Prefer attributes like `data-testid`, `aria-label`, or meaningful text. If possible, collaborate with the development team to introduce consistent attributes like data-testid for testability. Avoid relying on fragile attributes like dynamic classes or auto-generated IDs. For example,
```typescript
page.locator('[data-testid="submit-button"]').click();

```

### 2️⃣ Leverage Playwright's built-in Role-Based Selectors
Use semantic roles to ensure your tests adapt even if minor UI changes occur. For example,
```typescript
page.getByRole('button', { name: 'Submit' }).click();

```

### 3️⃣ Use Relative Locators
Instead of absolute selectors, use parent-child relationships. For example,
```typescript
page.locator('.parent-class').locator('button').click();
```

### 4️⃣ Handle Dynamic Elements
If selectors change based on conditions, use logic to find the correct element dynamically. For example,
```typescript
const button = await page.locator('text=Submit').first
```

### 5️⃣ Implement Waits & Retries
Ensuring elements are visible before interacting helps prevent failures. For example,
```typescript
await page.locator('[data-testid="submit-button"]').waitFor({ state: 'visible' });
```